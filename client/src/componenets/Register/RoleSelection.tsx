import { useNavigate } from "react-router-dom"

const RoleSelection = () => {
    const navigate = useNavigate();
    return (
        <div className="flex flex-col items-center gap-4 p-4">
            <h2 className="text-xl font-semibold">Select Role</h2>
            <button
                className="bg-blue-500 text-white px-4 py-2 rounded w-full"
                onClick={() => navigate('/register/customer')}
            >
                Continue as Customer
            </button>
            <button
                className="bg-green-600 text-white px-4 py-2 rounded w-full"
                onClick={() => navigate('/register/driver-step1')}
            >
                Continue as Driver
            </button>
        </div>
    );
}

export default RoleSelection
