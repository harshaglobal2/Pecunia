using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestPhoneBook.Entities;
using GuestPhoneBook.Exceptions;
using GuestPhoneBook.DataAccessLayer;

namespace GuestPhoneBook.BusinessLayer
{
    public class GuestBL
    {
        private static bool ValidateGuest(Guest guest)
        {
            StringBuilder sb = new StringBuilder();
            bool validGuest = true;
            if (guest.GuestID <= 0)
            {
                validGuest = false;
                sb.Append(Environment.NewLine + "Invalid Guest ID");

            }
            if (guest.GuestName == string.Empty)
            {
                validGuest = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (guest.GuestContactNumber.Length < 10)
            {
                validGuest = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            if (validGuest == false)
                throw new GuestPhoneBookException(sb.ToString());
            return validGuest;
        }

        public static bool AddGuestBL(Guest newGuest)
        {
            bool guestAdded = false;
            try
            {
                if (ValidateGuest(newGuest))
                {
                    GuestDAL guestDAL = new GuestDAL();
                    guestAdded = guestDAL.AddGuestDAL(newGuest);
                }
            }
            catch (GuestPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return guestAdded;
        }

        public static List<Guest> GetAllGuestsBL()
        {
            List<Guest> guestList = null;
            try
            {
                GuestDAL guestDAL = new GuestDAL();
                guestList = guestDAL.GetAllGuestsDAL();
            }
            catch (GuestPhoneBookException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return guestList;
        }

        public static Guest SearchGuestBL(int searchGuestID)
        {
            Guest searchGuest = null;
            try
            {
                GuestDAL guestDAL = new GuestDAL();
                searchGuest = guestDAL.SearchGuestDAL(searchGuestID);
            }
            catch (GuestPhoneBookException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchGuest;

        }

        public static bool UpdateGuestBL(Guest updateGuest)
        {
            bool guestUpdated = false;
            try
            {
                if (ValidateGuest(updateGuest))
                {
                    GuestDAL guestDAL = new GuestDAL();
                    guestUpdated = guestDAL.UpdateGuestDAL(updateGuest);
                }
            }
            catch (GuestPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return guestUpdated;
        }

        public static bool DeleteGuestBL(int deleteGuestID)
        {
            bool guestDeleted = false;
            try
            {
                if (deleteGuestID > 0)
                {
                    GuestDAL guestDAL = new GuestDAL();
                    guestDeleted = guestDAL.DeleteGuestDAL(deleteGuestID);
                }
                else
                {
                    throw new GuestPhoneBookException("Invalid Guest ID");
                }
            }
            catch (GuestPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return guestDeleted;
        }
       
    }
}
