using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestRunner.Core;
using WinFormsTestRunner.Models;

namespace WinFormsTestRunner.Steps
{
    internal class ChangeContextStep(GenericStep step) : Step(step.Name, step.Action, step.ElementXPath, step.ElementId)
    {
        public string ContextId { get; set; } = step.ContextId ?? string.Empty;

        public override void HandleAction()
        {
            if (ContextId == "default")
            {
                TestRunner.Driver?.SwitchTo().DefaultContent();
            }
            else
            {
                var iframe = TestRunner.Driver?.FindElement(By.Id(ContextId));
                TestRunner.Driver?.SwitchTo().Frame(iframe);
            }
        }
    }
}
