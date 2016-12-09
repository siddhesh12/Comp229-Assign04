using System;
using System.Collections.Generic;
using System.Linq;
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

            baseLabel.Text = charModel._base + "mm";
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

        }
        protected void updateButtonClicked(object sender, EventArgs e)
        {
            if(updateButton.Text == "update")
            {
                hideLabels();
                updateButton.Text = "done";
                cancelButton.Visible = true;
            }
            else
            {
                updateModel();
                updateButton.Text = "update";
                cancelButton.Visible = false;
                loadData();


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
    }
}