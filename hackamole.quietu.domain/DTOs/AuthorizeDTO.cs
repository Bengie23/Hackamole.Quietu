namespace hackamole.quietu.domain.DTOs;

public class AuthorizeDTO {

  public AuthorizeDTO(string productoCode)
  {
    ProductCode = productoCode;    
  }

  public AuthorizeDTO()
  {
  }

  public string ProductCode { get; set; }

}