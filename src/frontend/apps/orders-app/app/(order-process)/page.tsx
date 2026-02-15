import AddressContextProvider from "./AddressContext";
import RestaurantSearch from "./components/RestaurantSearch";

export default function OrderProcessPage() {
  return (
    <div className="min-h-screen p-8">
      <main className="max-w-4xl mx-auto">
        <h1 className="text-4xl font-bold mb-4">Order Process Page</h1>

      <div className="mt-8">
          <RestaurantSearch />
      </div>
      </main>
    </div>
  );
}