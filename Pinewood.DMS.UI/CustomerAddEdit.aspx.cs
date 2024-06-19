using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

public partial class CustomerAddEdit : System.Web.UI.Page
{
    private const string PageHeaderCreate = "Add Customer";
    private const string PageHeaderEdit = "Edit Customer";
    protected async void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["customerId"] != null)
            {
                var customerId = Convert.ToInt32(Request.QueryString["customerId"]);
                if (customerId > 0)
                {
                    await GetCustomerById(Convert.ToInt32(customerId));
                    AddEditHeader.Text = PageHeaderEdit;
                }
                else
                {
                    AddEditHeader.Text = PageHeaderCreate;
                }
            }
            else
            {
                AddEditHeader.Text = PageHeaderCreate;
            }
        }
    }

    protected async void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int customerStatus;
            if (int.TryParse(CustomerStatus.SelectedValue, out customerStatus))
            {
                var customerData = new JObject();
                customerData["FirstName"] = FirstName.Text.Trim();
                customerData["LastName"] = LastName.Text.Trim();
                customerData["Email"] = Email.Text.Trim();
                customerData["Mobile"] = Mobile.Text.Trim();
                customerData["Gender"] = Gender.SelectedValue;
                customerData["Address1"] = Address1.Text.Trim();
                customerData["Address2"] = Address2.Text.Trim();
                customerData["City"] = City.Text.Trim();
                customerData["State"] = State.Text.Trim();
                customerData["PostCode"] = PostCode.Text.Trim();
                customerData["Country"] = Country.Text.Trim();
                customerData["CustomerStatus"] = customerStatus;

                if (string.IsNullOrEmpty(CustomerId.Value))
                {
                    var result = await CreateCustomer(customerData);
                    if (result.Success)
                    {
                        Response.Redirect("ManageCustomer.aspx");
                    }
                    else
                    {
                        ShowAlert("Error while creating customer. Please try again.");
                    }
                }
                else
                {
                    customerData["CustomerId"] = Convert.ToInt32(CustomerId.Value);
                    var result = await UpdateCustomer(customerData);
                    if (result.Success)
                    {
                        Response.Redirect("ManageCustomer.aspx");
                    }
                    else
                    {
                        ShowAlert("Error while updating customer. Please try again.");
                    }
                }
            }
        }
    }

    private async Task<ApiResponse> CreateCustomer(JObject customerRequest)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
                var relativeUrl = "createCustomer";

                var json = customerRequest.ToString();
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(relativeUrl, content);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }

    private async Task<ApiResponse> UpdateCustomer(JObject customerRequest)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
                var relativeUrl = "updateCustomer";
                var json = customerRequest.ToString();
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(relativeUrl, content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }

    private async Task<string> GetCustomerById(int customerId)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
                var relativeUrl = $"getCustomerById?customerId={customerId}";
                var response = await client.GetAsync(relativeUrl);

                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var customerData = JsonConvert.DeserializeObject<ApiResponse>(result.ToString());
                if (customerData.Success && customerData.Result != null)
                {
                    dynamic apiResponse = JsonConvert.DeserializeObject(customerData.Result.ToString());
                    var customer = apiResponse;
                    CustomerId.Value = customer["customerId"].ToString();
                    FirstName.Text = customer["firstName"].ToString();
                    LastName.Text = customer["lastName"].ToString();
                    Email.Text = customer["email"].ToString();
                    Mobile.Text = customer["mobile"].ToString();
                    Gender.SelectedValue = customer["gender"].ToString();
                    Address1.Text = customer["address1"].ToString();
                    Address2.Text = customer["address2"].ToString();
                    City.Text = customer["city"].ToString();
                    State.Text = customer["state"].ToString();
                    PostCode.Text = customer["postCode"].ToString();
                    Country.Text = customer["country"].ToString();
                    CustomerStatus.SelectedValue = customer["customerStatus"].ToString();

                }
                else
                {
                    Console.WriteLine("Error: Failed to deserialize API response.");
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

    private void ShowAlert(string message)
    {
        string script = $"alert('{message}');";
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
    }
}

