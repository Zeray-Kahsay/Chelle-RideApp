import { useState } from 'react';
import { useRegisterUser } from '../services/userService';
import type { RegisterUserRequest } from '../types/RegisterUserRequest';

const RegistrationForm = () => {
    const [formData, setFormData] = useState<RegisterUserRequest>({
        phoneNumber: '',
        firstName: '',
        lastName: '',
        password: '',
        ConfirmPassword: '',
        role: '',
        email: ''
    });

    const { mutateAsync, isPending, isSuccess, isError, error } = useRegisterUser();

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            await mutateAsync(formData);
        } catch (err) {
            console.error('Registration failed');
        }
    };

    return (
        <form onSubmit={handleSubmit} className="max-w-md mx-auto bg-white p-6 rounded-lg shadow-md space-y-4">
            <input
                name="phoneNumber"
                className="w-full p-2 border border-gray-300 rounded"
                value={formData.phoneNumber}
                onChange={handleChange}
                placeholder="Phone Number"
                required
            />
            <input
                name="firstName"
                className="w-full p-2 border border-gray-300 rounded"
                value={formData.firstName}
                onChange={handleChange}
                placeholder="First Name"
                required
            />
            <input
                name="lastName"
                className="w-full p-2 border border-gray-300 rounded"
                value={formData.lastName}
                onChange={handleChange}
                placeholder="Last Name"
                required
            />
            <input
                name="password"
                type="password"
                className="w-full p-2 border border-gray-300 rounded"
                value={formData.password}
                onChange={handleChange}
                placeholder="Password"
                required
            />
            <input
                name="email"
                className="w-full p-2 border border-gray-300 rounded"
                value={formData.email}
                onChange={handleChange}
                placeholder="Email (optional)"
            />
            <select
                name="role"
                className="w-full p-2 border border-gray-300 rounded"
                value={formData.role}
                onChange={handleChange}
            >
                <option value="" disabled>Select Role</option>
                <option value="Customer">Customer</option>
                <option value="Driver">Driver</option>
            </select>
            <button
                type="submit"
                disabled={isPending}
                className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600"
            >
                {isPending ? 'Registering...' : 'Register'}
            </button>

            {isSuccess && <p className="text-green-600 text-center">Registration successful!</p>}
            {isError && <p className="text-red-600 text-center">Something went wrong. Try again.</p>}
        </form>
    );
};

export default RegistrationForm;
