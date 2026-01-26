export default function Logo() {
  return (
    <div className="flex items-center gap-2">
      <svg 
        width="40" 
        height="40" 
        viewBox="0 0 40 40" 
        fill="none" 
        xmlns="http://www.w3.org/2000/svg"
        className="text-emerald-600"
      >
        <circle 
          cx="20" 
          cy="20" 
          r="18" 
          stroke="currentColor" 
          strokeWidth="2"
          fill="none"
        />
        <path 
          d="M14 10 L14 18 M12 10 L12 16 C12 17 12.5 18 14 18 M16 10 L16 16 C16 17 15.5 18 14 18" 
          stroke="currentColor" 
          strokeWidth="1.5" 
          strokeLinecap="round"
        />
        <path 
          d="M26 10 L26 18 M24 10 C24 10 24 14 26 14" 
          stroke="currentColor" 
          strokeWidth="1.5" 
          strokeLinecap="round"
        />
        <circle cx="20" cy="24" r="3" fill="currentColor" opacity="0.6" />
        <ellipse cx="16" cy="26" rx="2" ry="1.5" fill="currentColor" opacity="0.4" />
        <ellipse cx="24" cy="26" rx="2" ry="1.5" fill="currentColor" opacity="0.4" />
      </svg>
      <span className="text-2xl font-bold text-gray-800">
        RestaurantApp
      </span>
    </div>
  );
}
