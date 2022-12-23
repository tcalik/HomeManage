import { createSlice } from "@reduxjs/toolkit";

const initialState = { counter: 4 };



const userSlice = createSlice({
  name: "user",
  initialState: initialState,
  reducers: {
    increment(state) {
      state.counter++;
    },
  },
});



export const userActions = userSlice.actions;

export default userSlice.reducer