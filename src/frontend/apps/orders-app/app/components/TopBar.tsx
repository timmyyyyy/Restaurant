import Logo from './Logo';
import { UserIcon, UserPlusIcon } from '@heroicons/react/24/outline';

export default function TopBar() {
  return (
    <header className="bg-white border-b border-gray-200 shadow-sm">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between items-center h-16">
          <div className="flex-shrink-0">
            <Logo />
          </div>
          
          <nav className="flex items-center gap-3">
            <button className="flex items-center gap-2 px-5 py-2 text-sm font-medium text-gray-700 bg-white border border-gray-300 rounded-lg hover:bg-gray-50 hover:border-gray-400 transition-all duration-200 hover:shadow-sm">
              <UserIcon className="w-4 h-4" />
              Sign In
            </button>
            <button className="flex items-center gap-2 px-5 py-2 text-sm font-medium text-white bg-emerald-600 rounded-lg hover:bg-emerald-700 transition-all duration-200 hover:shadow-md">
              <UserPlusIcon className="w-4 h-4" />
              Sign Up
            </button>
          </nav>
        </div>
      </div>
    </header>
  );
}
