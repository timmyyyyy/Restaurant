import type { Metadata } from "next";
import "./globals.css";

export const metadata: Metadata = {
  title: "Restaurant Admin - Restaurant",
  description: "Manage your restaurant menu, orders, and settings",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        {children}
      </body>
    </html>
  );
}
