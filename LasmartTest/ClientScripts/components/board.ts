import Konva from "konva";
import { CommentService, PointService } from "../services";

export class Board {

    private readonly _pointService = new PointService();
    private readonly _commentService = new CommentService();
    constructor() { }

    public async ShowAsync(containerId: string, width: number, height: number): Promise<void> {

        const points = await this._pointService.getAllAsync();
        const allComments = await this._commentService.searchAsync(points.map(p => p.id));

        const stage = new Konva.Stage({
            container: containerId,
            width: width,
            height: height,
        });

        const layer = new Konva.Layer();

        points.forEach(point => {
            const pointGroup = new Konva.Group({
                x: point.positionX,
                y: point.positionY,
            });

            const circle = new Konva.Circle({
                radius: point.radius,
                fill: point.color,
            });
            circle.on('dblclick', async () => {
                const id = point.id;
                await this._pointService.deleteAsync(id);
                pointGroup.destroy();
            });
            pointGroup.add(circle);

            const comments = allComments.filter(c => c.pointId == point.id);

            comments.forEach((comment, index) => {
                const commentGroup = new Konva.Group({
                    x: -comment.text.length * 10 / 2,
                    y: point.radius + 4 + 22 * index,
                });

                commentGroup.add(new Konva.Rect({
                    width: comment.text.length * 10,
                    height: 18,
                    fill: comment.background,
                    stroke: 'black',
                    strokeWidth: 1,
                }));

                commentGroup.add(new Konva.Text({
                    width: comment.text.length * 10,
                    height: 18,
                    text: comment.text,
                    fontSize: 18,
                    align: 'center',
                }));

                pointGroup.add(commentGroup);
            });

            layer.add(pointGroup);
        });

        stage.add(layer);
        layer.draw();
    }

}