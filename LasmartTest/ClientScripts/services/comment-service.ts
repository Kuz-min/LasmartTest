import { PointComment } from "../models";

export class CommentService {

    public async searchAsync(pointIds: number[]): Promise<PointComment[]> {
        const params = new URLSearchParams({
            pointIds: pointIds.join(','),
        });

        return fetch('/api/comments/search?' + params)
            .then(response => {
                if (response.ok)
                    return response.json();
                else
                    throw new Error(response.statusText);
            });
    }

}