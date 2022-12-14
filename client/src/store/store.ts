import { configureStore } from '@reduxjs/toolkit'
import authReducer from './authSlice'

const reducer = {
  auth: authReducer
} 

export const store = configureStore({
  reducer: reducer,
  devTools: true
})

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch