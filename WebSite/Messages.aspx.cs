using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.TechnicalServices;

namespace WebSite
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ReadMessagesButton_Click(object sender, EventArgs e)
        {
            DataSet messages = GetDatabaseManager().GetAllMessages();
            Session["MessageTable"] = messages.Tables[0];
            MessagesGridView.DataSource = messages;
            MessagesGridView.DataBind();
        }

        private DatabaseManager GetDatabaseManager()
        {
            if (Cache["DatabaseManager"] == null)
            {
                string relativePath = Server.MapPath("~/App_Data/Messages.sdf");
                string connectionString = "Data Source=" + relativePath;
                Cache["DatabaseManager"] = new DatabaseManager(connectionString);
            }
            return (DatabaseManager)Cache["DatabaseManager"];
        }

        protected void MessagesGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable messageTable = (DataTable)Session["MessageTable"];
            String expression = e.SortExpression;

            if (messageTable.DefaultView.Sort == expression + " ASC")
            {
                messageTable.DefaultView.Sort = expression + " DESC";
            }
            else
            {
                messageTable.DefaultView.Sort = expression + " ASC";
            }
            Session["MessageTable"] = messageTable;
            
            MessagesGridView.DataSource = messageTable;
            MessagesGridView.DataBind();
        }
    }
}