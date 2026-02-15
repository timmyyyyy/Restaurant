import AddressContextProvider from './AddressContext';

export default function OrderProcessLayout({ children }: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <AddressContextProvider>
            {children}
        </AddressContextProvider>
    )
}