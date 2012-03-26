using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shady_Pines
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Button event for clicking the register button. 
        // Should try and add the user to the database.
        protected void createNewMember(object sender, EventArgs e)
        {
            Member myMember = new Member();

            myMember._MemberID = Convert.ToInt32(txtMemberID.Text);
            myMember._MemberStatusID = Convert.ToInt32(ddlMemberPayment.SelectedValue);
            myMember._MembershipCategoryID = Convert.ToInt32(ddlMemberPackage.SelectedValue);
            myMember._MembershipID = Convert.ToInt32(ddlMemberType.SelectedValue);
            myMember._MemberFName = txtMemberFName.Text;
            myMember._MemberLName = txtMemberLName.Text;
            myMember._MemberCountry = txtMemberCountry.Text;
            myMember._MemberState = txtMemberState.Text;
            myMember._MemberAddress = txtMemberAddress.Text;
            myMember._MemberCity = txtMemberCity.Text;
            myMember._MemberZip = txtMemberZip.Text;
            myMember._MemberPhone = txtMemberPhone.Text;

            Member.InsertMember(myMember);

            try
            {
                odsMembers.Insert();
            }
            catch (Exception ex)
            {
                lblError.EnableViewState = true;
                lblError.Text = "A database error has occurred." +
                    "Message: " + ex.Message;
                Session["Exception"] = ex;
                ex = Server.GetLastError();
            }
            finally
            {
            }
        }

    }
}