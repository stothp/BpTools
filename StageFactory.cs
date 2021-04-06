using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsWPFClientTest
{
    static class StageFactory
    {
        public static Stage GetObject(BpTools.Stage stage)
        {
            if (stage is BpTools.StageAction)
            {
                return new StageAction((BpTools.StageAction)stage);
            }
            else if (stage is BpTools.StageAlert)
            {
                return new StageAlert((BpTools.StageAlert)stage);
            }
            else if (stage is BpTools.StageAnchor)
            {
                return new StageAnchor((BpTools.StageAnchor)stage);
            }
            else if (stage is BpTools.StageBlock)
            {
                return new StageBlock((BpTools.StageBlock)stage);
            }
            else if (stage is BpTools.StageCalculation)
            {
                return new StageCalculation((BpTools.StageCalculation)stage);
            }
            else if (stage is BpTools.StageChoice)
            {
                return new StageChoice((BpTools.StageChoice)stage);
            }
            else if (stage is BpTools.StageChoiceEnd)
            {
                return new StageChoiceEnd((BpTools.StageChoiceEnd)stage);
            }
            else if (stage is BpTools.StageCollection)
            {
                return new StageCollection((BpTools.StageCollection)stage);
            }
            else if (stage is BpTools.StageCode)
            {
                return new StageCode((BpTools.StageCode)stage);
            }
            else if (stage is BpTools.StageData)
            {
                return new StageData((BpTools.StageData)stage);
            }
            else if (stage is BpTools.StageDecision)
            {
                return new StageDecision((BpTools.StageDecision)stage);
            }
            else if (stage is BpTools.StageEnd)
            {
                return new StageEnd((BpTools.StageEnd)stage);
            }
            else if (stage is BpTools.StageException)
            {
                return new StageException((BpTools.StageException)stage);
            }
            else if (stage is BpTools.StageLoop)
            {
                return new StageLoop((BpTools.StageLoop)stage);
            }
            else if (stage is BpTools.StageLoopEnd)
            {
                return new StageLoopEnd((BpTools.StageLoopEnd)stage);
            }
            else if (stage is BpTools.StageMultipleCalculation)
            {
                return new StageMultipleCalculation((BpTools.StageMultipleCalculation)stage);
            }
            else if (stage is BpTools.StageNote)
            {
                return new StageNote((BpTools.StageNote)stage);
            }
            else if (stage is BpTools.StagePage)
            {
                return new StagePage((BpTools.StagePage)stage);
            }
            else if (stage is BpTools.StageProcess)
            {
                return new StageProcess((BpTools.StageProcess)stage);
            }
            else if (stage is BpTools.StageRecover)
            {
                return new StageRecover((BpTools.StageRecover)stage);
            }
            else if (stage is BpTools.StageResume)
            {
                return new StageResume((BpTools.StageResume)stage);
            }
            else if (stage is BpTools.StageStart)
            {
                return new StageStart((BpTools.StageStart)stage);
            }
            else if (stage is BpTools.StagePageInfo)
            {
                return new StagePageInfo((BpTools.StagePageInfo)stage);
            }
            else
            {
                throw new Exception("Unknown object type: " + stage.GetType());
            }
        }
    }
}
