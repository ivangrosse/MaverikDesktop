using System;

public class User
{
    [Key]
    public String id { get; set; }
    [Required]
    public String nombre { get; set; }
    [Required]
    public String apellido { get; set; }
    [Required]
    [MaxLength(15)]
    [Index(IsUnique = true)]
    public String usuario { get; set; }
    [Required]
    [MaxLength(15)]
    public String password { get; set; }

    public User()
	{ 
	}


}
