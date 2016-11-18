using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        var viewAll = Contact.GetAllContacts();
        return View["index.cshtml", viewAll];
      };
      Get["/contacts/new"] =_=> View["new-contact-form.cshtml"];
      Post["/contacts/contact-added"] =_=>
      {
        Contact newContact = new Contact(Request.Form["name"], Request.Form["address"], Request.Form["phone"], Request.Form["details"]);
        return View["contact-added.cshtml", newContact];
      }
    }
  }
}
