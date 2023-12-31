import React from 'react';

interface Rating{
    value:number
}


const Rating = ({value}:Rating) => {
  // Giả sử value là số lượng sao từ 0 đến 5
  const maxRating = 5;

  return (
    <div className="flex items-center">
      {[...Array(maxRating)].map((_, index) => (
        <svg
          key={index}
          xmlns="http://www.w3.org/2000/svg"
          className={`h-5 w-5 ${index < value ? 'text-yellow-500' : 'text-gray-300'}`}
          fill="currentColor"
          viewBox="0 0 20 20"
        >
          <path
            fillRule="evenodd"
            d="M10 2.52l1.82 5.575H18.5a.5.5 0 01.448.724l-4.104 3.025 1.553 5.569a.5.5 0 01-.766.565L10 16.31l-4.682 3.108a.5.5 0 01-.766-.564l1.553-5.57L1.052 8.82a.5.5 0 01.448-.725H8.18L10 2.52z"
            clipRule="evenodd"
          />
        </svg>
      ))}
    </div>
  );
};

export default Rating;
