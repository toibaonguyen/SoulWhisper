import { createSlice } from '@reduxjs/toolkit';

interface UserState{
    role:string|null
    id:string|null
}

const counterSlice = createSlice({
  name: 'user',
  initialState:<UserState> {
    role: null,
    id:null
  },
  reducers: {
    setUserState: (state,action) => {
      state.role =action.payload.role;
      state.id=action.payload.id;
    },
    // Other reducers/actions here
  },
});

export const {setUserState } = counterSlice.actions;
export default counterSlice.reducer;
