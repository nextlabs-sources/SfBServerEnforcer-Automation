using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;

// NEXTLABS
using NLLyncEndpointProxy.Common;
using NLLyncEndpointProxy.Listener;

// Other project
using QAToolSFBCommon.CommandHelper;
using QAToolSFBCommon.NLLog;
using QAToolSFBCommon.Common;

namespace NLLyncEndpointProxy
{
    public partial class NLLyncEndpointProxyForm : Form, IMessageDisplayer
    {
        #region Logger
        static protected CLog theLog = CLog.GetLogger(typeof(NLLyncEndpointProxyForm));
        #endregion

        #region Const/Readonly values
        public const string kstrXmlManulClassifyObligations = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                                           "<SFBClassification type = \"manulClassifyObligation\">" +
                                                "<Layer name=\"itar\" editable=\"false\" default=\"yes\" values=\"yes|no\">" +
                                                    "<Layer name=\"level\" editable=\"false\" default=\"1\" values=\"1|2|3|4|5\" relyOn=\"yes\">" +
                                                        "<Layer name=\"classify\" editable=\"false\" default=\"yes\" values=\"yes|no\" relyOn=\"4|5\"/>" +
                                                    "</Layer>" +
                                                    "<Layer name=\"kaka\" editable=\"false\" default=\"1\" values=\"1|2|3|4|5\" relyOn=\"yes\"/>" +
                                                "</Layer>" +
                                                "<Layer name=\"description\" editable=\"false\" default=\"yes\" values=\"protected meeting|normal meeting\"></Layer>" +
                                            "</SFBClassification>";
        public static readonly string kstrNewXmlManulClassifyObligations = kstrXmlManulClassifyObligations;

        public const string kstrXmlClassifyTags = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                                    "<SFBClassification type = \"classifyTags\">" +
                                                        "<Layer name=\"itar\" values=\"yes\"/>" +
                                                        "<Layer name=\"level\" values=\"5\"/>" +
                                                        "<Layer name=\"classify\" values=\"yes\"/>" +
                                                        "<Layer name=\"description\" values=\"protected meeting\"/>" +
                                                    "</SFBClassification>";
        #endregion

        public NLLyncEndpointProxyForm(string strTitle)
        {
            InitializeComponent();
            NLLyncEndpointProxy.NLMessagingFlow.NLIMFlow.SetIMessageDisplayer(this);

            theLog.OutputLog(EMSFB_LOGLEVEL.emLogLevelDebug, "Title:{0}\n", strTitle);
            if (!string.IsNullOrEmpty(strTitle))
            {
                this.Text += " - " + strTitle;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            NLLyncEndpointProxyMain.s_obNLLyncEndpointProxyObj.CurLyncEndpoint.SendNotifyMessage(true, comboxUsers.Text, textSendMessage.Text, "");
        }

        #region Implement Interface: ISaveMessage
        public void SaveMessage(string strMessage)
        {
            textReceivedMessage.Text += strMessage;
        }
        #endregion
    }
}
