using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    [AttributeUsage(AttributeTargets.All)]
    public class CanBeEditedAttribute : Attribute
    {
        public CanBeEditedAttribute(bool canBeEdited)
        {
            CanBeEdited = canBeEdited;
        }

        public bool CanBeEdited { get; set; }
        public bool getCanBeEdited()
        {
            return CanBeEdited;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class CanBeDeletedAttribute : Attribute
    {
        public CanBeDeletedAttribute(bool canBeEdited)
        {
            CanBeDeleted = canBeEdited;
        }

        public bool CanBeDeleted { get; set; }
        public bool getCanBeDeleted()
        {
            return CanBeDeleted;
        }
    }


    [AttributeUsage(AttributeTargets.All)]
    public class NotesExistAttribute : Attribute
    {
        public NotesExistAttribute(bool _notesExist)
        {
            notesExist = _notesExist;
        }

        public bool notesExist { get; set; }
        public bool getNotesExist()
        {
            return notesExist;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class CanBeEditedAfterHalfHourAttribute : Attribute
    {
        public CanBeEditedAfterHalfHourAttribute(bool canBeEdited)
        {
            CanBeEdited = canBeEdited;
        }

        public bool CanBeEdited { get; set; }
        public bool getCanBeEdited()
        {
            return CanBeEdited;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class NameToBeDisplayedOnUIAttribute : Attribute
    {
        public NameToBeDisplayedOnUIAttribute(string displayname)
        {
            Displayname = displayname;
        }

        public string Displayname { get; set; }
        public string getDisplayname()
        {
            return Displayname;
        }
    }
}
