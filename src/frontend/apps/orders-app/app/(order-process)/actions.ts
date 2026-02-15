"use server";

export default async function SearchRestaurant(formData: FormData) {
    const address = formData.get("address");

    if (!address || address === "") {
        throw new Error("Address is required");
    }

    
}