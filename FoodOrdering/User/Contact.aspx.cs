using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace FoodOrdering.User
{
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                DisplayError("Name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                DisplayError("Email is required.");
                return;
            }
            if (!IsValidEmail(txtEmail.Text))
            {
                DisplayError("Please enter a valid email address.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                DisplayError("Subject is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                DisplayError("Message is required.");
                return;
            }

            // Try to insert data into the database if validation passes
            try
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("ContactSp", con);
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Subject", txtSubject.Text.Trim());
                cmd.Parameters.AddWithValue("@Message", txtMessage.Text.Trim());
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                lblMsg.Visible = true;
                lblMsg.Text = "Thanks for reaching out! We will look into your query.";
                lblMsg.CssClass = "alert alert-success";
                clear();
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
            finally
            {
                con.Close();
            }
        }

        // Helper method to clear input fields
        private void clear()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }

        // Helper method to display error messages
        private void DisplayError(string message)
        {
            lblMsg.Visible = true;
            lblMsg.Text = message;
            lblMsg.CssClass = "alert alert-danger";
        }

        // Method to validate email format
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
