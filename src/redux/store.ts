import { configureStore } from '@reduxjs/toolkit';
import rootReducer from './reducers'; // Import your root reducer here

const store = configureStore({
  reducer: rootReducer,
  // Other configuration options if needed
});

export default store;
