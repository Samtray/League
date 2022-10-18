
    public class Security
    {
    public static bool ValidateToken(string username, string token) {
            if (token == "123456"){
                return true;
            }

            return false;
        }

    public static ErrorResponse GetError(SecurityError error) { 
      
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.Status = (int)error;
            errorResponse.ErrorMessage = error.ToString();
            return errorResponse;
        }
    }



