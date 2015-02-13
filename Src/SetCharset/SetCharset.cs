using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BizTalkComponents.Utils;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using IComponent = Microsoft.BizTalk.Component.Interop.IComponent;

namespace BizTalkComponents.PipelineComponents.SetCharset
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("250D7FF6-5A84-4527-9225-53F1F2FEBFD4")]
    [ComponentCategory(CategoryTypes.CATID_Decoder)]
    public partial class SetCharset : IComponent, IBaseComponent,
                                        IPersistPropertyBag, IComponentUI
    {
        [DisplayName("Target Charset")]
        [Description("The charset that should be used for the incomming message.")]
        [RequiredRuntime]
        public string TargetCharset { get; set; }
        private const string TargetCharsetPropertyName = "TargetCharset";
       
        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            string errorMessage;

            if (!Validate(out errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            var availableEncodings = Encoding.GetEncodings();

            if (availableEncodings.All(a => a.Name != TargetCharset))
            {
                throw new ArgumentException("Invalid Charset specified.");
            }

            pInMsg.BodyPart.Charset = TargetCharset;

            return pInMsg;
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            TargetCharset = PropertyBagHelper.ToStringOrDefault(PropertyBagHelper.ReadPropertyBag(propertyBag, TargetCharsetPropertyName), string.Empty);
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            PropertyBagHelper.WritePropertyBag(propertyBag, TargetCharsetPropertyName, TargetCharset);
        }
    }
}
