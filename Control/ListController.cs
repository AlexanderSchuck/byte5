using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;

namespace ToDo_App.Control
{
    public class ListController : UmbracoApiController
    {
        #region Declaration
        ApplicationContext ac { get; }
        ServiceContext Services { get; }
        DatabaseContext DatabaseContext { get; }
        UmbracoHelper umbraco { get; }
        UmbracoContext UmbracoContext { get; }
        ContentService cs;
        #endregion

        #region Constructors
        public ListController()
        {
            ac = new ApplicationContext(CacheHelper.NoCache);
            cs = (ContentService)ac.Services.ContentService;
        }
        #endregion

        #region Methods
        #region CRUD
        //Get All ToDoLists
        public Umbraco.Core.Models.IContent GetAllToDoLists()
        {
           var content = cs.GetById(1234);
           return content;
        }

        //Get a ToDoLists by its name
        public Umbraco.Core.Models.IContent GetToDoListByName()
        {
            //find out how to get lists id
            var content = cs.GetById(1234);
            return content;
        }

        //create dummy list for testdata 
        public void createDummyList()
        {
            //at first some dummy properties
            int userId = 0;
            int parentId = 1;
            DateTime creationDate = DateTime.UtcNow;
            string theListsname = "ToDo list for ToDo App";

            //now begin with filling content
            var content = cs.CreateContent("List", parentId, "ToDoLists", userId);
            content.SetValue("List_Name", theListsname);
            content.SetValue("creationDate", creationDate);

            cs.SaveAndPublishWithStatus(content);
        }

        //real method for creating a list
        public void createList(string ListName, DateTime creationDate, int parentId, int userId)
        {
            var content = cs.CreateContent("List", parentId, "ToDoLists", userId);
            content.SetValue("List_Name", ListName);
            content.SetValue("creationDate", creationDate);

            cs.SaveAndPublishWithStatus(content);
        }

        //create a single list entry
        public void createListEntry(string descr, DateTime creationDate, int parentId, int userId)
        {
            var content = cs.CreateContent("List", parentId, "ToDoLists", userId);
            content.SetValue("Description", descr);
            content.SetValue("creationDate", creationDate);
            content.SetValue("IsFinished", false);

            cs.SaveAndPublishWithStatus(content);
        }

        //get all todos of a list
        public IEnumerable<Umbraco.Core.Models.IContent> getEntrysOfList(int idOfList)
        {
            var listEntries = cs.GetChildren(idOfList);

            return listEntries;
        }

        //delete a whole list
        public void deleteList(int listId)
        {
            var content = cs.GetById(listId);
        }
        #endregion
        #endregion
    }
}