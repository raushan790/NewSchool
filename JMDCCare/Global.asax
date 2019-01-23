<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Credit", "Credit", "~/Credit.aspx");
        routes.MapPageRoute("Debit", "Debit", "~/Debit.aspx");
        routes.MapPageRoute("StudentDetails", "StudentDetails", "~/Student.aspx");
        routes.MapPageRoute("AddCustomer", "AddCustomer", "~/NewCustomer.aspx");
    }
</script>
