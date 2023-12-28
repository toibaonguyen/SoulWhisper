// SearchBar.tsx

import React, { useState, ChangeEvent } from 'react';
import styles from './index.module.css'; // Import CSS module

interface SearchBarProps {
  onSearch: (searchValue: string) => void;
}

const SearchBar: React.FC<SearchBarProps> = ({ onSearch }) => {
  const [searchValue, setSearchValue] = useState<string>('');

  const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
    setSearchValue(event.target.value);
  };

  const handleSearchSubmit = () => {
    onSearch(searchValue);
  };

  return (
    <div className={styles['search-bar-container']}>
      <input
        type="text"
        value={searchValue}
        onChange={handleSearchChange}
        placeholder="Search for doctors..."
        className={styles['search-input']}
      />
      <button onClick={handleSearchSubmit} className={styles['search-button']}>
        Search
      </button>
    </div>
  );
};

export default SearchBar;
