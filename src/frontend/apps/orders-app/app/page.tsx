export default function Home() {
  return (
    <div className="p-8">
      <main className="max-w-4xl mx-auto">
        <h1 className="text-4xl font-bold mb-8 text-gray-900">Orders App</h1>
        
        {/* Content Panel */}
        <div className="bg-white rounded-lg border border-gray-200 shadow-sm p-8">
          <div className="space-y-4">
            <h2 className="text-2xl font-semibold text-gray-800">Put your address, to see available restaurants...</h2>
            <div className="pt-4">
              <button className="px-6 py-2 bg-emerald-600 text-white rounded-lg hover:bg-emerald-700 transition-colors duration-200">
                Browse Restaurants
              </button>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
}
