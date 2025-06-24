export interface RegisterUserRequest {
    phoneNumber: string;
    firstName: string;
    lastName: string;
    password: string;
    ConfirmPassword: string;
    email?: string;
    role: string; // 'Customer' or 'Driver'
}
