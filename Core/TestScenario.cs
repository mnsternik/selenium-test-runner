using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.Steps;
using WinFormsTestRunner.Utilities;

namespace WinFormsTestRunner.Models
{
    internal class TestScenario
    {
        public string Name { get; set; } = string.Empty;
        public List<Step> Steps { get; set; } = [];

        public static TestScenario LoadScenario(string path)
        {
            var ts = JSONFileHandler.Deserialize<TestScenario>(path);
            ValidateScenario(ts);

            ts.Steps = CreateListOfSteps(ts);
            return ts; 
        }

        public static List<Step> CreateListOfSteps(TestScenario ts)
        {
            List<Step> steps = [];
            int stepNumber = 0;

            foreach (var step in ts.Steps)
            {
                steps.Add(TransformIntoSpecifedStep(step, stepNumber));
                stepNumber++;
            }

            return steps;
        }

        public static Step TransformIntoSpecifedStep(Step step, int stepNumber)
        {
            return step.Action switch
            {
                "navigate" => new NavigateStep(step),
                "click" => new ClickStep(step),
                "select" => new SelectStep(step),
                "verify" => new VerifyStep(step),
                "iframe-change" => new ChangeContextStep(step),
                "write" => new WriteStep(step),
                "manual" or "credentials" => new ManualStep(step),
                _ => throw new InvalidStepParameterException($"Nieprawidłowy rodzaj akcji w kroku {stepNumber} w parametrze {nameof(step.Action)}: '{step.Action}'"),
            };
        }

        private static void ValidateScenario(TestScenario ts)
        {
            if (ts.Steps == null || ts.Steps.Count == 0)
            {
                throw new InvalidScenarioException("Scenariusz testowy nie zawiera żadnych kroków testowych");
            }
            else if (string.IsNullOrEmpty(ts.Name))
            {
                throw new InvalidScenarioException("Scenariusz testowy nie posiada nazwy, należy dospiać wartość w atrybucie 'name' w pliku scenariuszowym");
            }
        }
    }
}
