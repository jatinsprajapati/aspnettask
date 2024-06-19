using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

public partial class ManageCustomer : System.Web.UI.Page
{
    protected async void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            await GetCustomerList();                
        }
    }

    private async Task<string> GetCustomerList()
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
                var relativeUrl = "getCustomerList";
                var response = await client.GetAsync(relativeUrl);               
                response.EnsureSuccessStatusCode();              
                var result = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(result))
                {
                    dynamic apiResponse = JsonConvert.DeserializeObject(result);
                    if (apiResponse != null && apiResponse.success == true && apiResponse.result != null)
                    {
                        var customers = new List<dynamic>();
                        foreach (var item in apiResponse.result)
                        {
                            customers.Add(item);
                        }
                        GridView1.DataSource = customers;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Console.WriteLine("Error: Failed to deserialize API response.");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var customerId = button.CommandArgument;
        Response.Redirect($"CustomerAddEdit.aspx?customerId={customerId}");
    }

    protected void btnAddCustomer_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerAddEdit.aspx");
    }
}

