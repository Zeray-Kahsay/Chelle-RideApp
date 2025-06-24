export interface RegisterCustomerRequest {
  phoneNumber: string;
  firstName: string;
  lastName: string;
  email?: string;
  role: "Customer"; // fixed role
}
