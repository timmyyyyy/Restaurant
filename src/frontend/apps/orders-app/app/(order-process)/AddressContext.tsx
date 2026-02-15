"use client";
import { createContext, useContext, useState, Dispatch, SetStateAction } from "react";

export interface AddressContextType {
  address: string | null;
  setAddress: Dispatch<SetStateAction<null>>;
}

const AddressContext = createContext<AddressContextType | undefined>(undefined)
export const useAddress = () => {
    const context = useContext(AddressContext);
    if (!context) {
        throw new Error("useAddress must be used within an AddressContextProvider");
    }
    return context;
}

export default function AddressContextProvider({children}: {children: React.ReactNode}) {
    const [address, setAddress] = useState(null);

    return (
        <AddressContext.Provider value={{ address, setAddress }}>
            {children}
        </AddressContext.Provider>
    )
}