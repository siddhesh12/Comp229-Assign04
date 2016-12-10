using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Comp229_Assign04.Model.CharacterModels;
using static Comp229_Assign04.Model.CharacterModels.Specialability;

namespace Comp229_Assign04
{
    public partial class Character : System.Web.UI.Page
    {
        private CharacterModel charModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            var name = Request.QueryString["name"];
            var faction = Request.QueryString["faction"];

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(faction))
            {
                Response.Redirect("~/HomePage.aspx");
                return;
            }

            charModel = Global.characters.FirstOrDefault(tModel => tModel.name == name && tModel.faction == faction);
            loadData();
            updateButton.Visible = true;
            cancelButton.Visible = false; 
        }


        private void loadData()
        {
            factionImg.ImageUrl = charModel.imageUrl;
    
            name.Text = charModel.name;
            name.Visible = true;
            nameTextField.Visible = false;

            faction.Text = charModel.faction;
            faction.Visible = true;
            factionTextBox.Visible = false;

            rank.Text = charModel.rank.ToString();
            rank.Visible = true;
            rankTextBox.Visible = false;

            baseLabel.Text = charModel._base.ToString();
            baseLabel.Visible = true;
            baseTextBox.Visible = false;

            size.Text = charModel.size.ToString();
            size.Visible = true;
            sizeTextBox.Visible = false;

            deploymentZone.Text = charModel.deploymentZone.ToString();
            deploymentZone.Visible = true;
            deploymentZoneTextBox.Visible = false;

            mobility.Text = charModel.mobility.ToString();
            mobility.Visible = true;
            mobilityTextBox.Visible = false;

            resiliance.Text = charModel.resiliance.ToString();
            resiliance.Visible = true;
            resilianceTextBox.Visible = false;

            wounds.Text = charModel.wounds.ToString();
            wounds.Visible = true;
            woundsTextBox.Visible = false;


            traitsList.DataSource = charModel.traits;
            traitsList.DataBind();

            TypesList.DataSource = charModel.types;
            TypesList.DataBind();

            defenceChartList.DataSource = charModel.defenseChart;
            defenceChartList.DataBind();

            actionsList.DataSource = charModel.actions;
            actionsList.DataBind();

            speciaAbilitiesList.DataSource = charModel.specialAbilities;
            speciaAbilitiesList.DataBind();

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cancelButtonClicked(object sender, EventArgs e)
        {
            loadData();
            updateButton.Text = "Update";
            cancelButton.Visible = false;
        }
        protected void updateButtonClicked(object sender, EventArgs e)
        {
            if(updateButton.Text == "Update")
            {
                hideLabels();
                updateButton.Text = "Done";
                cancelButton.Visible = true;
            }
            else
            {
                updateModel();
                updateButton.Text = "Update";
                cancelButton.Visible = false;
                updateJson();
                loadData();

                email.Visible = true;
                cancelEmail.Visible = true;
                emailTextBox.Visible = true;
            }
        }


        private void updateJson()
        {
            using (StreamWriter streamWriter
                     = File.CreateText(System.Web.Hosting.HostingEnvironment.MapPath(Global.jsonPathNew)))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(Global.characters));
            }
        }
        private void updateModel()
        {
            if(nameTextField.Text != null)
            charModel.name = nameTextField.Text;

            if (factionTextBox.Text != null)
                charModel.faction = factionTextBox.Text;

            if (rankTextBox.Text != null)
                charModel.rank = int.Parse(rankTextBox.Text);

            if (baseTextBox.Text != null)
                charModel._base = int.Parse(baseTextBox.Text);

            if (sizeTextBox.Text != null)
                charModel.size = int.Parse(sizeTextBox.Text);

            if (resilianceTextBox.Text != null)
                charModel.resiliance = int.Parse(resilianceTextBox.Text);

            if (woundsTextBox.Text != null)
                charModel.wounds = int.Parse(woundsTextBox.Text);
        }
        private void hideLabels()
        {
            name.Visible = false;
            nameTextField.Visible = true;
            nameTextField.Text = name.Text;

            faction.Visible = false;
            factionTextBox.Visible = true;
            factionTextBox.Text = faction.Text;

            rank.Visible = false;
            rankTextBox.Visible = true;
            rankTextBox.Text = rank.Text;

            baseLabel.Visible = false;
            baseTextBox.Visible = true;
            baseTextBox.Text = baseLabel.Text;

            size.Visible = false;
            sizeTextBox.Visible = true;
            sizeTextBox.Text = size.Text;

            deploymentZone.Visible = false;
            deploymentZoneTextBox.Visible = true;
            deploymentZoneTextBox.Text = deploymentZone.Text;

            mobility.Visible = false;
            mobilityTextBox.Visible = true;
            mobilityTextBox.Text = mobility.Text;

            resiliance.Visible = false;
            resilianceTextBox.Visible = true;
            resilianceTextBox.Text = resiliance.Text;

            wounds.Visible = false;
            woundsTextBox.Visible = true;
            woundsTextBox.Text = wounds.Text;

        }
        private void hideTextFileds()
        {

        }

        private void emailButtonClicked()
        {
                if (IsValidEmail(emailTextBox.Text))
                {
                    sendEmail(emailTextBox.Text);
                    email.Visible = false;
                    emailTextBox.Visible = false;
                    cancelEmail.Visible = false;
                }
                else
                {
                    emailTextBox.Visible = true;
                    cancelEmail.Visible = true;
                }
         
        }

        private void sendEmail(string email)
        {
            EmailJsonFile(email, "siddhesh" );
        }

        public static void EmailJsonFile(string clientEmailAddress, string clientName)
        {
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage message = new MailMessage();
            try
            {
                MailAddress fromAddress = new MailAddress("cc-comp229f2016@outlook.com", "Comp229-Assign04");
                MailAddress toAddress = new MailAddress(clientEmailAddress, clientName);
                message.From = fromAddress;
                message.To.Add(toAddress);
                message.Subject = "Comp229-Assign04 email";
                message.Body = "Please find attached json file";

                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.EnableSsl = true;

                // SET UseDefaultCredentials to false BEFORE setting Credentials - we all have 'ugh' moments
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Global.emailID, Global.emailPassword);

                System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
                contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
                contentType.Name = Global.jsonFileName;
                message.Attachments.Add(new Attachment(System.Web.Hosting.HostingEnvironment.MapPath(attachmentFileName), contentType));

                smtpClient.Send(message);
                //statusLabel.Text = "Email sent.";
            }
            catch (Exception ex)
            {
                //statusLabel.Text = "Coudn't send the message!";
            }
        }

        private  bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void cancelEmailButton()
        {
            cancelEmail.Visible = false;
        }

    }
}