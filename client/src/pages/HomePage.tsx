import { Link } from "react-router-dom";

const HomePage = () => {
  return (
    <div className="flex flex-col items-center justify-center h-screen text-center space-y-6">
      <h1 className="text-4xl font-bold text-blue-600">Welcome to ON-TIME</h1>
      <h2 className="text-xl text-gray-700">Arrive ON TIME</h2>

      <div className="space-y-4">
        <p className="text-lg">
          Already have an account?{" "}
          <Link
            to="/login"
            className="text-blue-500 hover:underline font-semibold"
          >
            Login here
          </Link>
        </p>

        <p className="text-lg">
          New user?{" "}
          <Link
            to="register/role-selection"
            className="text-green-500 hover:underline font-semibold"
          >
            Register here
          </Link>
        </p>
      </div>
    </div>
  );
};

export default HomePage;
