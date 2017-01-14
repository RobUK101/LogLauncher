using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogLauncher
{
    public partial class aboutForm : Form
    {
        private const string helpformContent = @"e1xydGYxXGFuc2lcYW5zaWNwZzEyNTJcZGVmZjBcZGVmbGFuZzIwNTd7XGZvbnR0Ymx7XGYwXGZuaWxcZmNoYXJzZXQwIFNlZ29lIFVJO317XGYxXGZuaWxcZmNoYXJzZXQwIENhbGlicmk7fXtcZjJcZm5pbFxmY2hhcnNldDIgU3ltYm9sO319DQpcdmlld2tpbmQ0XHVjMVxwYXJkXHFjXGJcZjBcZnMxOCBMb2cgTGF1bmNoZXIgVjIuMiAtIFRoZSBoYW5keSB3YXkgdG8gY2hlY2sgb3V0IHlvdXIgbG9ncy5ccGFyDQpccGFyZFxiMFxwYXINClxmczE2IFJlcXVpcmVtZW50czogXHBhcg0KXHBhcg0KXHBhcmR7XHBudGV4dFxmMlwnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYyXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTcyMCBBZG1pbmlzdHJhdGl2ZSBTaGFyZXMsIFJlbW90ZSBSZWdpc3RyeSBhbmQgTmV0IDQuMFxwYXINClxwYXJkXHBhcg0KRmVhdHVyZXM6XHBhcg0KXHBhcg0KXHBhcmR7XHBudGV4dFxmMlwnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYyXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTcyMCBFYXNpbHkgdmlzdWFsaXNlIGNoYW5nZXMgdG8gdGhlIGxvZ3Mgb3ZlciB0aW1lIHVzaW5nIHRoZSBtb25pdG9yIGZlYXR1cmUsIHNldCB0aGUgZnJlcXVlbmN5IG1vbml0b3Jpbmcgc2hvdWxkIHRha2UgcGxhY2UsIGNob29zZSB5b3VyIGdyYWRpZW50IHN0YXJ0XFxlbmQgY29sb3VycywgYW5kIHRpY2sgXGIgTW9uaXRvciBMb2dzXGIwXHBhcg0KXHBhcmRccGFyDQpccGFyZHtccG50ZXh0XGYyXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjJccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpNzIwIE5vdGUgdGhhdCB0aGUgQWNjb3VudCB5b3UgbGF1bmNoIHRoaXMgdG9vbCB1bmRlciBtdXN0IGhhdmUgcmlnaHRzIHRvIHRoZSByZW1vdGUgZGV2aWNlLCBhbmQgbG9nIGxvY2F0aW9ucyBzZWFyY2hlZC5ccGFyDQpccGFyZFxwYXINClxwYXJke1xwbnRleHRcZjJcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mMlxwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGk3MjAgQ2hhbmdlIGEgQ29uZmlnTWdyXFxTQ0NNIFNpdGUgb3IgYSBDbGllbnRzIExvZyBTZXR0aW5ncyB1c2luZyB0aGUgXGIgTG9nIFNldHRpbmdzXGIwICBmZWF0dXJlLCByZW1lbWJlciB0byBjeWNsZSB0aGUgc2VydmljZSBmb3IgdGhlIFNpdGUgb3IgQWdlbnQgZm9yIGNoYW5nZXMgdG8gdGFrZSBlZmZlY3RccGFyDQpccGFyZFxwYXINClxwYXJke1xwbnRleHRcZjJcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mMlxwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGk3MjAgSGlkZSBBcmNoaXZlIGxvZ3MgKCoubG9fKSBmcm9tIHZpZXcgYnkgdGlja2luZyBIaWRlIEFyY2hpdmUgTG9nc1xwYXINClxwYXJkXHBhcg0KXHBhcmR7XHBudGV4dFxmMlwnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYyXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTcyMCBUbyBvcGVuIG11bHRpcGxlIGxvZ3MgaW4gaW5kaXZpZHVhbCBpbnN0YW5jZXMgb2YgQ01UcmFjZSAsIHVudGljayBPcGVuIG11bHRpcGxlIGxvZ3MgaW4gb25lIENNVHJhY2VccGFyDQpccGFyZFxwYXINClxwYXJke1xwbnRleHRcZjJcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mMlxwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGk3MjAgQ3VzdG9tIGxvY2F0aW9ucyBmb3Igc2Nhbm5pbmcgY2FuIGJlIGFkZGVkIGJ5IHNlbGVjdGluZyB0aGUgXGIgQ3VzdG9tIFBhdGhzXGIwICBidXR0b24sIGFuZCBlbnRlcmluZyBhIGZpeGVkIHZvbHVtZSBwYXRoIGFsb25nIHdpdGggYSBmaWxlIG1hc2tccGFyDQpccGFyZFxwYXINClxwYXJke1xwbnRleHRcZjJcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mMlxwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGk3MjAgTWFrZSBzdXJlIExvZ0xhdW5jaGVyIGhhcyBydW4gYW5kIGZvdW5kIENNVHJhY2UgYmVmb3JlIHJ1bm5pbmcgd2l0aCBhbHRlcm5hdGl2ZSBjcmVkZW50aWFscywgc28gdGhhdCBhIGZhbGwtYmFjayBDTVRyYWNlIGxvY2F0aW9uIGNhbiBiZSByZWNvcmRlZCBhbmQgdXNlZCBieSBMb2dMYXVuY2hlclxwYXINClxwYXJkXGZzMThccGFyDQpcZnMxNiBUaGFuayB5b3UgdGhlIHRvb2wgdGVzdGVycyB3aG8gZ2F2ZSBtZSB0aW1lLCBwb2ludGVkIG91dCBidWdzIGFuZCBpZGVhcyBhbG9uZyB0aGUgd2VlayBhbmQgYSBiaXQgb2YgZGV2ZWxvcG1lbnQgdGltZSBWMS4wIHRvIFYyLjAgdG9vayB0byBjb21wbGV0ZSwgWmVuZyBZaW5naHVhIChTYW5keSksIE1hcmsgQWxkcmlkZ2UsIFNpbW9uIERldHRsaW5nIGFuZCBQYXVsIFdpbnN0YW5sZXkuXHBhcg0KXGZzMThccGFyDQpcZnMxNiBXcml0dGVuIGJ5IFJvYmVydCBNYXJzaGFsbCAtIE5vdmVtYmVyIDIwMTZcZnMxOFxwYXINClxwYXJkXHNhMjAwXHNsMjc2XHNsbXVsdDFcbGFuZzlcZjFcZnMyMlxwYXINCn0NCg==";

        public aboutForm()
        {
            InitializeComponent();

            // Hide the loadRTF button, only used when the Help forms contents are to be updated

            b_loadRTF.Enabled = false;
            b_loadRTF.Visible = false;

            // Render the Help forms Contents from the Base64 encoded string helpformContent

            byte[] decodedString = System.Convert.FromBase64String(helpformContent);

            rtb_helpContent.Rtf = System.Text.Encoding.UTF8.GetString(decodedString);
        }

        private void b_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.rtb_helpContent.LoadFile(@"D:\OneDriveBusiness\SharePoint\SharePoint\SMSMarshallTeam - Documents\Products\LogLauncher\Help-Form-Contents.rtf");
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string StoreMe =
            System.Convert.ToBase64String(enc.GetBytes(this.rtb_helpContent.Rtf));
            System.Windows.Forms.MessageBox.Show(StoreMe);

        }
    }
}
