using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsData;
//Contributor: Calvin C
[Index("AgentId", Name = "EmployeesCustomers")]
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(25)]
    public string CustFirstName { get; set; } = null!;
    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(25)]
    public string CustLastName { get; set; } = null!;
    [Required(ErrorMessage = "Address is required")]
    [StringLength(75)]
    public string CustAddress { get; set; } = null!;
    [Required(ErrorMessage = "City is required")]
    [StringLength(50)]
    public string CustCity { get; set; } = null!;
    [Required(ErrorMessage = "Province is required")]
    [StringLength(2)]
    public string CustProv { get; set; } = null!;
    [Required(ErrorMessage = "Postal Code is required")]
    [RegularExpression("^([A-Za-z]\\d[A-Za-z][-]?\\d[A-Za-z]\\d)", ErrorMessage = "not a valid postal code")]
    [StringLength(7)]
    public string CustPostal { get; set; } = null!;
    [Required(ErrorMessage = "Country is required")]
    [StringLength(25)]
    public string? CustCountry { get; set; }
    [Required(ErrorMessage = "Home Number is required")]
    [RegularExpression("^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$", ErrorMessage = "Home number is not valid")]
    [StringLength(20)]
    public string? CustHomePhone { get; set; }
    [Required(ErrorMessage = "Business Number is required")]
    [RegularExpression("^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$", ErrorMessage = "Business Number is not valid")]
    [StringLength(20)]
    public string CustBusPhone { get; set; } = null!;
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Email is not valid")]
    [StringLength(50)]
    public string CustEmail { get; set; } = null!;

    public int? AgentId { get; set; }
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50)]
    public string? CustUsername { get; set; } = null!;
    [Required(ErrorMessage = "Password is required")]
    [StringLength(50)]
    public string? CustPassword { get; set; } = null!;

    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("CustPassword", ErrorMessage = "Password and Confirmation Password must match.")]
    [StringLength(50)]
    public string CustConfirmPassword { get; set; } = null!;

    [ForeignKey("AgentId")]
    [InverseProperty("Customers")]
    public virtual Agent? Agent { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("Customer")]
    public virtual ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();

    [InverseProperty("Customer")]
    public virtual ICollection<CustomersReward> CustomersRewards { get; set; } = new List<CustomersReward>();
}
