// utils/detectCountry.ts
export const detectCountryPhoneCode = async (): Promise<string | null> => {
  try {
    const res = await fetch("https://ipapi.co/json/");
    const data = await res.json();
    return data.country_code ?? null;
  } catch (error) {
    console.error("Failed to detect country:", error);
    return null;
  }
};
