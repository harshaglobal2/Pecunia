using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using GuestPhoneBook.Entities;
using GuestPhoneBook.Exceptions;

namespace GuestPhoneBook.DataAccessLayer
{
    public class GuestDAL
    {
        public static List<Guest> guestList = new List<Guest>();

        public bool AddGuestDAL(Guest newGuest)
        {
            bool guestAdded = false;
            try
            {
                guestList.Add(newGuest);
                guestAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return guestAdded;

        }

        public List<Guest> GetAllGuestsDAL()
        {
            return guestList;
        }

        public Guest SearchGuestDAL(int searchGuestID)
        {
            Guest searchGuest = null;
            try
            {
                foreach (Guest item in guestList)
                {
                    if (item.GuestID == searchGuestID)
                    {
                        searchGuest = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return searchGuest;
        }

        public List<Guest> GetGuestsByNameDAL(string guestName)
        {
            List<Guest> searchGuest = new List<Guest>();
            try
            {
                foreach (Guest item in guestList)
                {
                    if (item.GuestName == guestName)
                    {
                        searchGuest.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return searchGuest;
        }

        public bool UpdateGuestDAL(Guest updateGuest)
        {
            bool guestUpdated = false;
            try
            {
                for (int i = 0; i < guestList.Count; i++)
                {
                    if (guestList[i].GuestID == updateGuest.GuestID)
                    {
                        updateGuest.GuestName = guestList[i].GuestName;
                        updateGuest.GuestContactNumber = guestList[i].GuestContactNumber;
                        guestUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return guestUpdated;

        }

        public bool DeleteGuestDAL(int deleteGuestID)
        {
            bool guestDeleted = false;
            try
            {
                Guest deleteGuest = null;
                foreach (Guest item in guestList)
                {
                    if (item.GuestID == deleteGuestID)
                    {
                        deleteGuest = item;
                    }
                }

                if (deleteGuest != null)
                {
                    guestList.Remove(deleteGuest);
                    guestDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new GuestPhoneBookException(ex.Message);
            }
            return guestDeleted;

        }

    }
}
