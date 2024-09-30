using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Exceptions;
using WinFormsTestRunner.Steps;

namespace WinFormsTestRunner.Models
{
    internal class GenericStep
    {
        public string Action { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; } = string.Empty;
        public string? ElementId { get; set; } = string.Empty;
        public string? ElementXPath { get; set; } = string.Empty;
        public string? ContextId { get; set; } = string.Empty;
        public string? Value { get; set; } = string.Empty;
        public string? ExpectedValue { get; set; } = string.Empty;
        public string? OptionType { get; set; } = string.Empty;
        public string? CheckType { get; set; } = string.Empty;
        public bool? CheckInsideSelect { get; set; } = false;

        public static Step TransformIntoSpecifedStep(GenericStep step, int stepNumber)
        {
            return step.Action switch
            {
                "navigate" => new NavigateStep(step),
                "click" => new ClickStep(step),
                "select" => new SelectStep(step),
                "verify" => new VerifyStep(step),
                "iframe-change" => new ChangeContextStep(step),
                "write"  => new WriteStep(step),
                "manual" or "credentials" => new ManualStep(step),
                _ => throw new InvalidStepParameterException($"Nieprawidłowy rodzaj akcji w kroku {stepNumber} w parametrze {nameof(step.Action)}: '{step.Action}'"),
            };
        }

    }
}
