import { api } from './client'
import type { TaskItem } from '../types/taskItem'

export const getTasks = () => api.get<TaskItem[]>('/api/TaskItem')
