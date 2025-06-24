// utils/countryUtils.ts
import { getCountryCallingCode, type CountryCode } from "libphonenumber-js";

export const getDialCodeFromCountry = (code: string): string => {
  try {
    return `+${getCountryCallingCode(code as CountryCode)}`;
  } catch {
    return "+251"; // fallback to ETH
  }
};
