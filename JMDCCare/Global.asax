<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("AcademicSession", "AcademicSession", "~/AcademicSession.aspx");
        routes.MapPageRoute("Board", "Board", "~/BoardSetting.aspx");
        routes.MapPageRoute("BoardingCategory", "BoardingCategory", "~/BoardingCategorySetting.aspx");
        routes.MapPageRoute("City", "City", "~/CitySetting.aspx");
        routes.MapPageRoute("StudentDetails", "StudentDetails", "~/Student.aspx");
        routes.MapPageRoute("AddCustomer", "AddCustomer", "~/NewCustomer.aspx");
    }
</script>
