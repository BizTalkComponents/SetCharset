using System;
using System.Collections;
using System.Linq;
using BizTalkComponents.Utils;

namespace BizTalkComponents.PipelineComponents.SetCharset
{
    public partial class SetCharset
    {
        public string Name { get { return "SetCharset"; } }
        public string Version { get { return "1.0"; } }
        public string Description { get { return "Helps BizTalk identify what charset should be used on incomming message."; } }

        public void GetClassID(out Guid classID)
        {
            classID = Guid.Parse("E7F513B1-D097-4BD1-9686-C450E94BF7DA");
        }

        public void InitNew()
        {
            
        }

        public IEnumerator Validate(object projectSystem)
        {
            return ValidationHelper.Validate(this, false).ToArray().GetEnumerator();
        }

        public bool Validate(out string errorMessage)
        {
            var errors = ValidationHelper.Validate(this, true).ToArray();

            if (errors.Any())
            {
                errorMessage = string.Join(",", errors);

                return false;
            }

            errorMessage = string.Empty;

            return true;
        }

        public IntPtr Icon { get { return IntPtr.Zero; } }
    }
}