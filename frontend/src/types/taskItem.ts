export interface TaskItem {
  id: number
  title: string
  description?: string | null
  isCompleted: boolean
  dueDate?: string | null
  priority?: string | null
  createdAt: string
  updatedAt?: string | null
}
