export interface RegisterCustomerFormData {
  countryCode: string;
  phoneNumber: string;
  firstName: string;
  lastName: string;
  email?: string;
  role: "Customer";
}
