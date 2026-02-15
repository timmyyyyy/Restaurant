"use client";
import { useRef } from "react";
import { useAddress } from "../AddressContext";
export interface IProps {

}

export default function RestaurantSearch() {
    const { setAddress } = useAddress();
    const address = useRef("");
    // TODO: so far we just care about address on the submit (there is no validation, 
    // currently there is no point to setAddress on every change,
    // so in the future get rid of useRef)
    return (
        <form action={}>
            <input type="text" 
                placeholder="Podaj swój adres"
                onChange={(event) => address.current = event.target.value} 
            />
        </form>
    )
}