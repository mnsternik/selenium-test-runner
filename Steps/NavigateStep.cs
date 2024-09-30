using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Core;
using WinFormsTestRunner.Models;

namespace WinFormsTestRunner.Steps
{
    internal class NavigateStep(GenericStep step) : Step(step.Name, step.Action, step.ElementXPath, step.ElementId)
    {
        public string Url { get; set; } = step.Url ?? string.Empty;

        public override void HandleAction()
        {
            TestRunner.Driver?.Navigate().GoToUrl(Url);
        }
    }
}
