import type { Metadata } from "next";
import "./globals.css";
import TopBar from "./components/TopBar";
import BottomBar from "./components/BottomBar";

export const metadata: Metadata = {
  title: "Orders - Restaurant",
  description: "Orders App",
};

export default function RootLayout({ children }: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className="flex flex-col min-h-screen bg-gray-50">
        <TopBar />
        <main className="flex-1">
          {children}
        </main>
        <BottomBar />
      </body>
    </html>
  );
}
