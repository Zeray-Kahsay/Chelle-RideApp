import RoleSelection from "../componenets/Register/RoleSelection";
import RegisterationForm from "../componenets/RegistrationForm"

const RegisterPage = () => (
    <div>
        <h2 className="bg-indigo-600 text-white">Register</h2>
        <RegisterationForm />
        <RoleSelection />
    </div>
)

export default RegisterPage;


