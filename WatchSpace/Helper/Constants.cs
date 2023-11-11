using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchSpace.Helper
{
    public class Constants
    {
        public static string SetPasswordSubject = "Set Password";

        public static string ResetPasswordSubject = "Reset Password";

        public static string WatchSpace = "WatchSpace";

        public static string SetPasswordEmailTemplate = "Dear <b>:::First_Name::: :::Last_Name:::</b>," +
            "Your account created successfully. Please :::LINK::: to set your password";
        
        public static string ResetPasswordEmailTemplate = "Dear <b>:::First_Name::: :::Last_Name:::</b>," +
            "Please :::LINK::: to reset your password";
        
        public static string AdminEmailTemplate = "Dear <b>:::First_Name::: :::Last_Name:::</b>," +
            " </ br> :::Message:::";

        public static string OrderConfirmTemplate = "Dear <b>:::First_Name::: :::Last_Name:::</b>," +
            "</ br> Your order is confirmed and your order refrence number is <b>:::RefrenceNumber:::</b>.";

        public static string OrderStatusMessage = "Dear <b>:::First_Name::: :::Last_Name:::</b>," +
            "</ br> Your order Status is <b>:::Status:::</b> and your order refrence number is <b>:::RefrenceNumber:::</b>.";

        public static string KeyString = "E546C8DF278CD5931069B522E695D4F2";

        public static string RegisterSuccessMessage = "Account created successfully. Please check your email.";

        public static string ResetPasswordSuccessMessage = "Please check your email, to reset your password.";

        public static string SuccessMessage = "Saved Successfully";

        public static string ErrorMessage = "Something went wrong! Please try again.";

        public static string WatchSpaceAdmin = "Admin";

        public static string WatchSpaceUser = "User";

        public static string PasswordInfo = "Your password must be between 8 to 12 characters long, <br />" +
            "At Least One Uppercase, <br /> At Least One Lowercase, At Least One Digit and must contain special characters from @#$%&.";
    }
}
