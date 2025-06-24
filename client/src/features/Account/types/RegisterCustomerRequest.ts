export interface RegisterCustomerRequest {
  phoneNumber: string; // full phone number
  firstName: string;
  lastName: string;
  email?: string;
  role: "Customer"; // fixed role
}
