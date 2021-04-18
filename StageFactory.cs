using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsWPFClientTest
{
    static class StageFactory
    {
        public static Stage GetObject(BpToolsLib.Stage stage)
        {
            if (stage is BpToolsLib.StageAction)
            {
                return new StageAction((BpToolsLib.StageAction)stage);
            }
            else if (stage is BpToolsLib.StageAlert)
            {
                return new StageAlert((BpToolsLib.StageAlert)stage);
            }
            else if (stage is BpToolsLib.StageAnchor)
            {
                return new StageAnchor((BpToolsLib.StageAnchor)stage);
            }
            else if (stage is BpToolsLib.StageBlock)
            {
                return new StageBlock((BpToolsLib.StageBlock)stage);
            }
            else if (stage is BpToolsLib.StageCalculation)
            {
                return new StageCalculation((BpToolsLib.StageCalculation)stage);
            }
            else if (stage is BpToolsLib.StageChoice)
            {
                return new StageChoice((BpToolsLib.StageChoice)stage);
            }
            else if (stage is BpToolsLib.StageChoiceEnd)
            {
                return new StageChoiceEnd((BpToolsLib.StageChoiceEnd)stage);
            }
            else if (stage is BpToolsLib.StageCollection)
            {
                return new StageCollection((BpToolsLib.StageCollection)stage);
            }
            else if (stage is BpToolsLib.StageCode)
            {
                return new StageCode((BpToolsLib.StageCode)stage);
            }
            else if (stage is BpToolsLib.StageData)
            {
                return new StageData((BpToolsLib.StageData)stage);
            }
            else if (stage is BpToolsLib.StageDecision)
            {
                return new StageDecision((BpToolsLib.StageDecision)stage);
            }
            else if (stage is BpToolsLib.StageEnd)
            {
                return new StageEnd((BpToolsLib.StageEnd)stage);
            }
            else if (stage is BpToolsLib.StageException)
            {
                return new StageException((BpToolsLib.StageException)stage);
            }
            else if (stage is BpToolsLib.StageLoop)
            {
                return new StageLoop((BpToolsLib.StageLoop)stage);
            }
            else if (stage is BpToolsLib.StageLoopEnd)
            {
                return new StageLoopEnd((BpToolsLib.StageLoopEnd)stage);
            }
            else if (stage is BpToolsLib.StageMultipleCalculation)
            {
                return new StageMultipleCalculation((BpToolsLib.StageMultipleCalculation)stage);
            }
            else if (stage is BpToolsLib.StageNote)
            {
                return new StageNote((BpToolsLib.StageNote)stage);
            }
            else if (stage is BpToolsLib.StagePage)
            {
                return new StagePage((BpToolsLib.StagePage)stage);
            }
            else if (stage is BpToolsLib.StageProcess)
            {
                return new StageProcess((BpToolsLib.StageProcess)stage);
            }
            else if (stage is BpToolsLib.StageRecover)
            {
                return new StageRecover((BpToolsLib.StageRecover)stage);
            }
            else if (stage is BpToolsLib.StageResume)
            {
                return new StageResume((BpToolsLib.StageResume)stage);
            }
            else if (stage is BpToolsLib.StageStart)
            {
                return new StageStart((BpToolsLib.StageStart)stage);
            }
            else if (stage is BpToolsLib.StagePageInfo)
            {
                return new StagePageInfo((BpToolsLib.StagePageInfo)stage);
            }
            else
            {
                throw new Exception("Unknown object type: " + stage.GetType());
            }
        }
    }
}
